using AutoMapper;
using Bai4_HomeWork2_1721030651.Data;
using Bai4_HomeWork2_1721030651.Models;
using Bai4_HomeWork2_1721030651.Repository.Bai2.First_Approach;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Bai4_HomeWork2_1721030651.Repository.Bai2.First_Approach
{
    public class WardService : IRepository<Ward>
    {
        private readonly GenearalCatalogContext _context;
        private readonly IMapper _mapper;

        public WardService(GenearalCatalogContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Ward>> GetListAsync()
        {
            return await _context.Wards.ToListAsync();
        }

        public async Task<IEnumerable<Ward>> SearchAsync(Expression<Func<Ward, bool>> expression, bool exportDTO = true)
        {
            var ctx = _context.Wards;

            if (exportDTO is true)
                return await ctx.Where(expression).ToListAsync();

            return await ctx
                .Where(expression)
                .Include(x => x.District)
                .Select(x => new Ward
                {
                    Id = x.Id,
                    Name = x.Name,
                    NameSlug = x.NameSlug,
                    WardCode = x.WardCode,
                    DistrictId = x.DistrictId,
                    CreatedAt = x.CreatedAt,
                    CreatedBy = x.CreatedBy,
                    UpdatedAt = x.UpdatedAt,
                    UpdatedBy = x.UpdatedBy,
                    Status = x.Status,
                    Timer = x.Timer,
                    District = new District
                    {
                        Id = x.District.Id,
                        Name = x.District.Name,
                        NameSlug = x.District.NameSlug,
                        DistrictCode = x.District.DistrictCode,
                        ProvinceId = x.District.ProvinceId,
                        CreatedAt = x.District.CreatedAt,
                        CreatedBy = x.District.CreatedBy,
                        UpdatedAt = x.District.UpdatedAt,
                        UpdatedBy = x.District.UpdatedBy,
                        Status = x.District.Status,
                        Timer = x.District.Timer,
                    }
                }).ToListAsync();
        }

        public async Task<Ward> GetAsync(int id, bool exportDTO = true)
        {
            var ctx = _context.Wards;

            if (exportDTO is true)
                return await ctx.FirstOrDefaultAsync(x => x.Id == id);

            return await ctx
                .Include(x => x.District)
                .Select(x => new Ward
                {
                    Id = x.Id,
                    Name = x.Name,
                    NameSlug = x.NameSlug,
                    WardCode = x.WardCode,
                    DistrictId = x.DistrictId,
                    CreatedAt = x.CreatedAt,
                    CreatedBy = x.CreatedBy,
                    UpdatedAt = x.UpdatedAt,
                    UpdatedBy = x.UpdatedBy,
                    Status = x.Status,
                    Timer = x.Timer,
                    District = new District
                    {
                        Id = x.District.Id,
                        Name = x.District.Name,
                        NameSlug = x.District.NameSlug,
                        DistrictCode = x.District.DistrictCode,
                        ProvinceId = x.District.ProvinceId,
                        CreatedAt = x.District.CreatedAt,
                        CreatedBy = x.District.CreatedBy,
                        UpdatedAt = x.District.UpdatedAt,
                        UpdatedBy = x.District.UpdatedBy,
                        Status = x.District.Status,
                        Timer = x.District.Timer,
                    }
                }).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Ward> CreateAsync(Ward entity)
        {
            var ward = _mapper.Map<Ward>(entity);
            await _context.Wards.AddAsync(ward);
            await _context.SaveChangesAsync();
            return ward;
        }

        public async Task<Ward> UpdateAsync(Ward entity)
        {
            var mappedEntity = _mapper.Map<Ward>(entity);
            _context.Wards.Update(mappedEntity);
            await _context.SaveChangesAsync();
            return mappedEntity;
        }

        public int Delete(int id)
        {
            var country = _context.Wards.Find(id);
            if (country is null)
                return 0;

            _context.Wards.Remove(country);
            return _context.SaveChanges();
        }

        public async Task<int> MaxIdAsync(int id)
        {
            return await _context.Wards.MaxAsync(x => x.Id);
        }

        public async Task<int> MinIdAsync(int id)
        {
            return await _context.Wards.MinAsync(x => x.Id);
        }

        public bool CheckExists(int id)
        {
            return _context.Wards.Any(x => x.Id == id);
        }
    }
}
