﻿using GestionInventario.Models;

namespace GestionInventario.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public User? GetUserByEmail(string email);
        public User? GetUserByIdNumber(string idNumber);
        public List<User> GetAllUsers();
        public bool UpdateUserStatus(string idNumber, bool status);
        public bool Add(User user);
    }
}
