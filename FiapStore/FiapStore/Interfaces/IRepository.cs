﻿using FiapStore.Entities;

namespace FiapStore.Interfaces;

public interface IRepository<T> where T : Entity
{
    IList<T> GetAll();
    T GetById(int id);
    void Create(T entity);
    void Update(T entity);
    void Delete(int id);
}