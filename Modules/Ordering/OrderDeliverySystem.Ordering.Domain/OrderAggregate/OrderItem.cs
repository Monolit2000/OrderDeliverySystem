﻿using FluentResults;
using OrderDeliverySystem.CommonModule.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Ordering.Domain.OrderAggregate
{
    public class OrderItem : Entity
    {
        public Guid OrderItemId { get; private set; }

        public Guid ProductId { get; private set; }

        public string ProductName { get; private set; }

        public string PictureUrl { get; private set; }

        public decimal UnitPrice { get; private set; }

        public decimal Discount { get; private set; }

        public int Units { get; private set; }

        public DeliveryOptions DeliveryOptions { get; private set; }

        private OrderItem() { }

        public OrderItem(
            Guid orderItemId, 
            string productName, 
            decimal unitPrice, 
            decimal discount, 
            string pictureUrl, 
            int units = 1)
        {
            ProductId = orderItemId;
            ProductName = productName;
            UnitPrice = unitPrice;
            Discount = discount;
            Units = units;
            PictureUrl = pictureUrl;
            DeliveryOptions = DeliveryOptions.SelfPickup(DateTime.Now, "Default");
        }


        public OrderItem(
            Guid orderItemId, 
            string productName,
            decimal unitPrice, 
            decimal discount, 
            string pictureUrl,
            DeliveryOptions deliveryOptions, 
            int units = 1)
        {
            ProductId = orderItemId;
            ProductName = productName;
            UnitPrice = unitPrice;
            Discount = discount;
            PictureUrl = pictureUrl;
            DeliveryOptions = deliveryOptions; 
            Units = units;
        }



        public Result SetDefoultDeliveryOptions(DateTime dateTime, string selfPickupAddress)
        {
            DeliveryOptions = DeliveryOptions.SelfPickup(dateTime, selfPickupAddress);
            return Result.Ok(); 
        }

        public Result AddDeliveryProrerty(DateTime dateTime, string address)
        {
            DeliveryOptions = DeliveryOptions.Delivery(dateTime, address, 20); 
            return Result.Ok();
        }

        public Result ChangeDeliveryTime(DateTime newDeliveryDateTime)
        {
            if (DeliveryOptions.DeliveryDateTime < DateTime.Now.AddHours(1))
            {
                return Result.Fail("The new delivery time must be at least two hours from now.");
            }

            if (newDeliveryDateTime.Date != DeliveryOptions.DeliveryDateTime.Date)
            {
                return Result.Fail("The new delivery date must match the originally planned delivery date.");
            }

            DeliveryOptions = DeliveryOptions.Delivery(
                newDeliveryDateTime,
                DeliveryOptions.Address,
                DeliveryOptions.DeliveryCost);

            return Result.Ok();
        }

        public Result ChangeDeliveryAddress(string newAddress)
        {
            if (DeliveryOptions.DeliveryDateTime < DateTime.Now.AddHours(1))
            {
                return Result.Fail("Cannot change delivery address within 1 hour of delivery.");
            }

            if (string.IsNullOrEmpty(newAddress))
            {
                return Result.Fail("New address cannot be empty.");
            }

            DeliveryOptions = DeliveryOptions.Delivery(
                DeliveryOptions.DeliveryDateTime,
                newAddress,
                DeliveryOptions.DeliveryCost);

            return Result.Ok();
        }
    }
}
