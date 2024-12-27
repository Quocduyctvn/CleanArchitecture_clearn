using Aplication.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace Aplication.Features.Products.Commands
{
	public  class UpdateProductCommand : IRequest<int>
	{
        public int Id { get; set; }
        public string Name { get; set; }
		public string Description { get; set; }
		public decimal Rate { get; set; }

		internal class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, int>
		{
			private readonly IApplicationDbContext _context;
			public UpdateProductCommandHandler(IApplicationDbContext context)
			{
				_context = context;
			}

			public async Task<int> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
			{
				var product = await _context.Products.FirstOrDefaultAsync(i=> i.Id == request.Id);
				if (product != null)
				{
					product.Name = request.Name;
					product.Description = request.Description;
					product.Rate = request.Rate;
					_context.Products.Update(product);
					await _context.SaveChangesAsync();
					return product.Id;
				}
				return default;
			}
		}

	}
}
