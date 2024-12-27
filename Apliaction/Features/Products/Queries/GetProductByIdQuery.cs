using Aplication.Interfaces;
using Domain.Entites;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Features.Products.Queries
{
	public class GetProductByIdQuery : IRequest<Product>
	{
		public int Id { get; set; }
		// Lớp GetAllProductsQueryHandler là trình xử lý cho yêu cầu GetProductByIdQuery.
		internal class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
		{
			private readonly IApplicationDbContext _context;
			public GetProductByIdQueryHandler(IApplicationDbContext context)
			{
				_context = context;
			}
			public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
			{
				var result = await _context.Products.FirstOrDefaultAsync(i => i.Id == request.Id);
				return result;
			}
		}

	}


}
