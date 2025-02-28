using System;
using System.Collections.Generic;

namespace TcpServerApp
{
    /// <summary>
    /// Абстрактный базовый класс для всех комнат чата
    /// </summary>
    internal abstract class BaseRoom
    {
        /// <summary>
        /// Добавляет клиента в комнату (должен быть переопределен в дочерних классах)
        /// </summary>
        public virtual void AddRoom(ClientObject client) { }

        /// <summary>
        /// Получает список клиентов в комнате
        /// </summary>
        public virtual List<ClientObject> GetClients() => new List<ClientObject>();
    }

    /// <summary>
    /// Комната для мужчин
    /// </summary>
    internal class Room_Male : BaseRoom
    {
        public List<ClientObject> _clientMenRoom = new();

        /// <summary>
        /// Добавляет клиента в комнату для мужчин
        /// </summary>
        public override void AddRoom(ClientObject client)
        {
            _clientMenRoom.Add(client);
        }

        /// <summary>
        /// Получает список клиентов в комнате
        /// </summary>
        public override List<ClientObject> GetClients() => _clientMenRoom;
    }

    /// <summary>
    /// Комната для женщин
    /// </summary>
    internal class Room_Female : BaseRoom
    {
        public List<ClientObject> _clientFemRoom = new();

        /// <summary>
        /// Добавляет клиента в комнату для женщин
        /// </summary>
        public override void AddRoom(ClientObject client)
        {
            _clientFemRoom.Add(client);
        }

        /// <summary>
        /// Получает список клиентов в комнате
        /// </summary>
        public override List<ClientObject> GetClients() => _clientFemRoom;
    }

    /// <summary>
    /// Комната для детей
    /// </summary>
    internal class Room_Childrens : BaseRoom
    {
        public List<ClientObject> _clientChilRoom = new();

        /// <summary>
        /// Добавляет клиента в детскую комнату
        /// </summary>
        public override void AddRoom(ClientObject client)
        {
            _clientChilRoom.Add(client);
        }

        /// <summary>
        /// Получает список клиентов в комнате
        /// </summary>
        public override List<ClientObject> GetClients() => _clientChilRoom;
    }

    /// <summary>
    /// Общая комната для всех пользователей
    /// </summary>
    internal class Room_AllChat : BaseRoom
    {
        public List<ClientObject> _clientAllChatRoom = new();

        /// <summary>
        /// Добавляет клиента в общий чат
        /// </summary>
        public override void AddRoom(ClientObject client)
        {
            _clientAllChatRoom.Add(client);
        }

        /// <summary>
        /// Получает список клиентов в комнате
        /// </summary>
        public override List<ClientObject> GetClients() => _clientAllChatRoom;
    }
}
