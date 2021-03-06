﻿using System.Data.Entity;
using HospitalRegistryData;
using HospitalRegistryData.Entities;
using HospitalRegistryRepositories.interfaces;
using Repositories;

namespace HospitalRegistryRepositories.implementation
{
    public class DoctorRepository : Repository<Doctor>, IDoctorRepository
    {
        public DoctorRepository(DbContext context) : base(context) { }
    }
}

//unit of work