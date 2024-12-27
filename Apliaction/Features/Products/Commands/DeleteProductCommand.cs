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
	public  class DeleteProductCommand : IRequest<int>
	{
		public int Id { get; set; }

		internal class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, int>
		{
			private readonly IApplicationDbContext _context;
			public DeleteProductCommandHandler(IApplicationDbContext context)
			{
				_context = context;
			}

			public async Task<int> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
			{
				var product = await _context.Products.FirstOrDefaultAsync(i => i.Id == request.Id);
				if (product != null)
				{
					_context.Products.Remove(product);
					await _context.SaveChangesAsync();
					return request.Id;
				}
				return default;
			}
		}

	}
}
