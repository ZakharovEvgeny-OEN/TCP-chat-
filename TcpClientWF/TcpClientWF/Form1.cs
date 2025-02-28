using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;

namespace TcpClientWF
{
    public partial class Form1 : Form
    {
        private static TcpClient _client;
        private static StreamReader _reader;
        private static StreamWriter _writer;

        private static readonly string _host = "127.0.0.1";
        private static readonly int _port = 8888;

        private static string _chatName;
        private static string _userName;

        public Form1()
        {
            InitializeComponent();
            _client = new TcpClient(); // Инициализация клиента
        }

        private async void button_InChat_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBox_Name.Text))
                {
                    MessageBox.Show("Введите имя!");
                    return;
                }

                if (string.IsNullOrEmpty(_chatName))
                {
                    MessageBox.Show("Выберите чат!");
                    return;
                }

                _userName = textBox_Name.Text;

                if (!_client.Connected)
                {
                    await _client.ConnectAsync(_host, _port);
                    _reader = new StreamReader(_client.GetStream());
                    _writer = new StreamWriter(_client.GetStream());
                }

                if (_reader is null || _writer is null)
                {
                    MessageBox.Show("Ошибка подключения к серверу!");
                    return;
                }

                _ = Task.Run(() => ReceiveMessageAsync(_reader, this));

                await _writer.WriteLineAsync(_chatName);
                await _writer.FlushAsync();

                await _writer.WriteLineAsync(_userName);
                await _writer.FlushAsync();

                listBox1.Items.Add(ListMessages.MSG_ForEnterMessage);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private static async Task SendMessageAsync(string message, StreamWriter writer, Form1 form)
        {
            if (string.IsNullOrEmpty(message))
            {
                MessageBox.Show("Введите текст сообщения!");
                return;
            }

            try
            {
                await writer.WriteLineAsync(message);
                await writer.FlushAsync();
                Print(message, form);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка отправки сообщения: {ex.Message}");
            }
        }

        private static async Task ReceiveMessageAsync(StreamReader reader, Form1 form)
        {
            while (true)
            {
                try
                {
                    string message = await reader.ReadLineAsync();
                    if (!string.IsNullOrEmpty(message))
                        Print(message, form);
                }
                catch
                {
                    break;
                }
            }
        }

        private static void Print(string message, Form1 form)
        {
            form.Invoke((MethodInvoker)delegate
            {
                form.listBox1.Items.Add(message);
                form.listBox1.TopIndex = form.listBox1.Items.Count - 1;
            });
        }

        private async void button_SendMess_Click(object sender, EventArgs e)
        {
            if (_writer is null || _reader is null)
            {
                MessageBox.Show("Вы не подключены к серверу!");
                return;
            }

            string message = textBox_Message.Text;
            textBox_Message.Clear();

            await SendMessageAsync(message, _writer, this);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (_writer != null)
                {
                    _writer.WriteLine("EXIT");
                    _writer.Flush();
                }
            }
            catch { }

            _reader?.Close();
            _writer?.Close();
            _client?.Close();
        }

        private void checkBox_Men_CheckedChanged(object sender, EventArgs e) => _chatName = "MenRoom";
        private void checkBox_Fem_CheckedChanged(object sender, EventArgs e) => _chatName = "FemRoom";
        private void checkBox_Child_CheckedChanged(object sender, EventArgs e) => _chatName = "ChildRoom";
        private void checkBox_All_CheckedChanged(object sender, EventArgs e) => _chatName = "AllChat";
    }
}
