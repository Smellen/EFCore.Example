using AutoMapper;
using EFCore.Example.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Example.Application
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            ApplyMappings();
        }

        private void ApplyMappings()
        {
        }
    }
}
