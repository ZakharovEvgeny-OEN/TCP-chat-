using System.Net;
using System.Net.Sockets;

namespace TcpServerApp
{
    internal class ServerObject
    {
        private TcpListener _tcpListener;
        private List<ClientObject> _clients;

        // Чаты для разных групп пользователей
        private Room_Male _clientsRoomMan = new();
        private Room_Female _clientsRoomFem = new();
        private Room_Childrens _clientRoomChild = new();
        private Room_AllChat _clientAllChat = new();

        protected internal ServerObject()
        {
            _tcpListener = new TcpListener(IPAddress.Any, 8888);
            _clients = new List<ClientObject>();
        }

        /// <summary>
        /// Прослушивание входящих подключений
        /// </summary>
        protected internal async Task ListenAsync()
        {
            try
            {
                _tcpListener.Start();
                Console.WriteLine("Сервер запущен. Ожидание подключений ...");

                while (true)
                {
                    // Ожидание подключения нового клиента
                    TcpClient tcpClient = await _tcpListener.AcceptTcpClientAsync();
                    ClientObject clientObject = new ClientObject(tcpClient, this);

                    // Получаем название чата от клиента
                    string chatName = await clientObject.Reader.ReadLineAsync();
                    clientObject._chatName = chatName;

                    // Добавляем клиента в соответствующую комнату
                    switch (chatName)
                    {
                        case "MenRoom":
                            _clientsRoomMan.AddRoom(clientObject);
                            break;
                        case "FemRoom":
                            _clientsRoomFem.AddRoom(clientObject);
                            break;
                        case "ChildRoom":
                            _clientRoomChild.AddRoom(clientObject);
                            break;
                        case "AllChat":
                            _clientAllChat.AddRoom(clientObject);
                            break;
                        default:
                            Console.WriteLine($"Неизвестный чат: {chatName}");
                            continue;
                    }

                    _clients.Add(clientObject);
                    Task.Run(clientObject.UpdateAsync); // Запускаем процесс обработки сообщений клиента
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка в ListenAsync: {ex.Message}");
            }
            finally
            {
                Disconnect();
            }
        }

        /// <summary>
        /// Удаление клиента по ID
        /// </summary>
        protected internal void RemoveConnectionById(string id)
        {
            ClientObject? clientToRemove = _clients.FirstOrDefault(c => c.ID == id);
            if (clientToRemove != null)
            {
                _clients.Remove(clientToRemove);
                clientToRemove.Close();
            }

            // Проверяем и удаляем клиента из соответствующего чата
            if (TryRemoveClientFromRoom(_clientsRoomMan._clientMenRoom, id)) return;
            if (TryRemoveClientFromRoom(_clientsRoomFem._clientFemRoom, id)) return;
            if (TryRemoveClientFromRoom(_clientRoomChild._clientChilRoom, id)) return;
            if (TryRemoveClientFromRoom(_clientAllChat._clientAllChatRoom, id)) return;
        }

        /// <summary>
        /// Вспомогательный метод для удаления клиента из чата
        /// </summary>
        private bool TryRemoveClientFromRoom(List<ClientObject> room, string id)
        {
            ClientObject? client = room.FirstOrDefault(c => c.ID == id);
            if (client != null)
            {
                room.Remove(client);
                client.Close();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Отключение всех клиентов
        /// </summary>
        protected internal void Disconnect()
        {
            foreach (var client in _clients)
            {
                client.Close();
            }
            _tcpListener.Stop();
        }

        /// <summary>
        /// Рассылка сообщения клиентам в чате (кроме отправителя)
        /// </summary>
        protected internal async Task BroadcastMessageAsync(string message, string senderID, string userName, string chatName)
        {
            string formattedMessage = $"{userName} из чата-{chatName} => {message}";
            List<ClientObject> targetRoom = chatName switch
            {
                "MenRoom" => _clientsRoomMan._clientMenRoom,
                "FemRoom" => _clientsRoomFem._clientFemRoom,
                "ChildRoom" => _clientRoomChild._clientChilRoom,
                "AllChat" => _clientAllChat._clientAllChatRoom,
                _ => null
            };

            if (targetRoom != null)
            {
                foreach (var client in targetRoom)
                {
                    if (client.ID != senderID)
                    {
                        await client.Writer.WriteLineAsync(formattedMessage);
                        await client.Writer.FlushAsync();
                    }
                }
            }
        }
    }
}
