﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Insurance.Domain.AggregatesModel.PolicyAggregate;
using Insurance.Domain.SeedWork;

namespace Insurance.Infrastructure.Repositories
{
    public class PolicyRepository : IPolicyRepository
    {
        private readonly InsuranceDbContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public PolicyRepository(InsuranceDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Add(Policy policy)
        {
            _context.Policies.Add(policy);
            _context.SaveChanges();
        }

        public Policy Get(int? policyId)
        {
            return _context.Policies.Find(policyId);
        }

        public ICollection<Policy> GetAll()
        {
            return _context.Policies.ToList();
        }

        public void Remove(int policyId)
        {
            Policy policy = this.Get(policyId);
            _context.Policies.Remove(policy);
            _context.SaveChanges();
        }

        public void Update(Policy policy)
        {
            var entity = _context.Policies.Find(policy.PolicyId);
            if (entity == null)
            {
                return;
            }

            _context.Entry(entity).CurrentValues.SetValues(policy);
            _context.SaveChanges();
        }
    }
}
