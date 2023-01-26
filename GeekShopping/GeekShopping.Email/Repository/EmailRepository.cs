﻿using AutoMapper;
using GeekShopping.Email.Messages;
using GeekShopping.Email.Model;
using GeekShopping.Email.Model.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GeekShopping.Email.Repository
{
    public class EmailRepository : IEmailRepository
    {
        private readonly DbContextOptions<MySQLContext> _context;
        private IMapper _mapper;

        public EmailRepository(DbContextOptions<MySQLContext> context)
        {
            _context = context;
        }
        public async Task LogEmail(UpdatePaymentResultMessage message)
        {
            EmailLog email = new EmailLog()
            {
                Email = message.Email,
                SentDate = System.DateTime.Now,
                Log = $"Order - {message.OrderId} has been created successfully!"
            };
            await using var _db = new MySQLContext(_context);
            _db.Emails.Add(email);
            await _db.SaveChangesAsync();

        }
    }
}
