﻿
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Tmp.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<GameServer.PlatformerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
    } 
}