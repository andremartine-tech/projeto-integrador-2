using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoIntegrador2.API.Data;
using ProjetoIntegrador2.API.DTOs;

namespace ProjetoIntegrador2.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutoController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public ProdutoController(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProdutoDto>>> GetAll()
    {
        var produtos = await _context.Produtos.AsNoTracking().ToListAsync();
        return Ok(_mapper.Map<IEnumerable<ProdutoDto>>(produtos));
    }
}
