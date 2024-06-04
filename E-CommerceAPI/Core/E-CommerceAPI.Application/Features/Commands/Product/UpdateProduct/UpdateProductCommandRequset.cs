﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceAPI.Application.Features.Commands.Product.UpdateProduct
{
    public class UpdateProductCommandRequset : IRequest<UpdateProductCommandResponse>
    {
        public string Id { get; set; }

        public string Name { get; set; }
        public int Stock { get; set; }
        public float Price { get; set; }
    }
}
