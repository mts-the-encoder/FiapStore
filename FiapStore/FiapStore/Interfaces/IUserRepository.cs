﻿using FiapStore.Entities;
using FiapStore.Interfaces;

namespace FiapStore.Interface;

public interface IUserRepository : IRepository<User>
{
    public User GetWithOrders(int id);
    public User GetByNameAndPassword(string name, string password);
}