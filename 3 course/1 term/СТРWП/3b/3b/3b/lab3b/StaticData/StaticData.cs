﻿using lab7.Models;

namespace lab7.StaticData;

public static class StaticData
{
    public static List<User> users = new()
    {
        new User() { Email = "admin@belstu.by", Password = "Admin11/", Roles = new[] { Roles.Administrator } },
    };
}