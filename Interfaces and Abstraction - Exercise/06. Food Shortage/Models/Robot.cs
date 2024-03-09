﻿using FoodShortage.Models.Interfaces;

namespace FoodShortage.Models
{
    public class Robot : IIdentifiable
    {
        public Robot(string model, string id)
        {
            Model = model;
            Id = id;
        }

        public string Model { get; set; }
        public string Id { get; private set; }
    }
}
