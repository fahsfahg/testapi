namespace TestApi.Services;

using AutoMapper;
using TestApi.Models;
using TestApi.Helpers;
using TestApi.Models.Prefix;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

public interface IPrefixService
{
    Task<IEnumerable<TbJobprefix>> GetAll();
    Task<TbJobprefix> GetById(int id);
    Task Create(CreateRequest model);
    Task Update(int id, [FromBody] TbJobprefix tb_jobprefix);
    Task Delete(int id);
}

public class PrefixService : IPrefixService
{
    private DataContext _context;
    private readonly IMapper _mapper;

    public PrefixService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<IEnumerable<TbJobprefix>> GetAll()
    {
        return await _context.TbJobprefixs.ToListAsync();
    }

    public async Task<TbJobprefix> GetById(int id)
    {
        return await Task.Run(() => getUser(id));
    }

    private TbJobprefix getUser(int id)
    {
        var user = _context.TbJobprefixs.Find(id);
        if (user == null) throw new KeyNotFoundException("User not found");
        return user;
    }

    public async Task Create(CreateRequest model)
    {
        var user = _mapper.Map<TbJobprefix>(model);

        _context.TbJobprefixs.Add(user);
        await _context.SaveChangesAsync();
    }

    public async Task Update(int id, [FromBody] TbJobprefix tb_jobprefix)
    {
        var prefix = _context.TbJobprefixs.Where(p => p.Id == id).FirstOrDefault<TbJobprefix>();

        if (prefix != null)
        {
            prefix.Description = tb_jobprefix.Description;
            prefix.Isdefault = tb_jobprefix.Isdefault;
            prefix.Isactive = tb_jobprefix.Isactive;

            // _context.TbJobprefixs.Update(prefix);
            await _context.SaveChangesAsync();
        }
    }

    public async Task Delete(int id)
    {
        var user = getUser(id);
        _context.TbJobprefixs.Remove(user);
        await _context.SaveChangesAsync();
    }
}