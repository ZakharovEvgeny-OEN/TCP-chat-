using System.Net.Sockets;

namespace TcpServerApp
{
    internal class ClientObject
    {
        protected internal string ID { get; } = Guid.NewGuid().ToString();
        protected internal StreamWriter Writer { get; }
        protected internal StreamReader Reader { get; }

        private string? _userName;  // Имя пользователя
        public string? _chatName;   // Название чата, к которому подключился клиент

        private TcpClient _client;
        private ServerObject _server;

        public ClientObject(TcpClient client, ServerObject server)
        {
            _client = client;
            _server = server;

            var stream = client.GetStream();
            Reader = new StreamReader(stream);
            Writer = new StreamWriter(stream) { AutoFlush = true };
        }

        /// <summary>
        /// Основной цикл получения сообщений от клиента (паттерн Update)
        /// </summary>
        public async Task UpdateAsync()
        {
            try
            {
                // Получаем имя пользователя
                _userName = await Reader.ReadLineAsync();
                if (string.IsNullOrWhiteSpace(_userName))
                {
                    _userName = "Аноним";  // Если имя пустое, даем дефолтное значение
                }

                // Сообщаем в чат, что новый пользователь вошел
                await SendMessageAsync("вошел в чат!", _userName);

                // Цикл обработки сообщений клиента
                while (true)
                {
                    try
                    {
                        string? message = await Reader.ReadLineAsync();

                        // Если клиент закрыл соединение — выходим
                        if (message == null)
                            break;

                        if (message == "EXIT")
                        {
                            await SendMessageAsync("покинул чат!", _userName);
                            break;
                        }

                        // Отправляем сообщение в чат
                        await SendMessageAsync(message, _userName);
                    }
                    catch
                    {
                        // Обрабатываем разрыв соединения (клиент отключился неожиданно)
                        await SendMessageAsync("покинул чат!", _userName);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка в UpdateAsync: {ex.Message}");
            }
            finally
            {
                // Удаляем клиента из списка на сервере
                _server.RemoveConnectionById(ID);
            }
        }

        /// <summary>
        /// Закрытие соединения с клиентом
        /// </summary>
        protected internal void Close()
        {
            Reader.Close();
            Writer.Close();
            _client.Close();
        }

        /// <summary>
        /// Отправка сообщения всем клиентам в чате
        /// </summary>
        private async Task SendMessageAsync(string message, string userName)
        {
            await _server.BroadcastMessageAsync(message, ID, userName, _chatName);
            Console.WriteLine($"{userName} из чата {_chatName} => {message}");
        }
    }
}
