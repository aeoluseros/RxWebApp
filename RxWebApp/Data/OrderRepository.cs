﻿using System;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using RxWebApp.Data.Entities;

namespace RxWebApp.Data
{
    internal sealed class OrderRepository : RepositoryBase, IOrderRepository
    {
        private static int orderIdCounter;

        public OrderRepository(IDataContextFactory dbFactory)
            : base(dbFactory)
        {
            orderIdCounter = 0;
        }

        public IObservable<OrderEntity> CreateOrder(int customerId)
        {
            return CreateOrder(customerId, null);
        }

        public IObservable<OrderEntity> CreateOrder(int customerId, IScheduler scheduler)
        {
            var order = new OrderEntity { CustomerId = customerId, Id = orderIdCounter++ };
            if (scheduler != null)
            {
                return Observable.Return(order, scheduler);
            }
            return Observable.Return(order);
        }

        public IObservable<Unit> DeleteOrder(int orderId)
        {
            return DeleteOrder(orderId, null);
        }

        public IObservable<Unit> DeleteOrder(int orderId, IScheduler scheduler)
        {
            if (scheduler != null)
            {
                return Observable.Return(new Unit(), scheduler);
            }
            return Observable.Return(new Unit());
        }
    }
}