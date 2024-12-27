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
	public  class GetAllProductsQuery : IRequest<IEnumerable<Product>>
	{
		// Lớp GetAllProductsQueryHandler là trình xử lý cho yêu cầu GetAllProductsQuery.
		internal class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
		{
			private readonly IApplicationDbContext _context;
            public GetAllProductsQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
			{
				var result = await _context.Products.ToListAsync(cancellationToken);
				return result;
			}
		}

	}


}
