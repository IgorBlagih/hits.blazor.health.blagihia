using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using HealthSystemApp.Data;
namespace HealthSystemApp.Data
{
    public class HealthService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public HealthService(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // Получить все записи текущего пользователя
        public async Task<List<HealthRecord>> GetUserRecordsAsync(string userId)
        {
            return await _context.HealthRecords
                .Where(r => r.UserId == userId)
                .OrderByDescending(r => r.Date)
                .ToListAsync();
        }

        // Добавить новую запись
        public async Task AddRecordAsync(HealthRecord record, string userId)
        {
            record.UserId = userId;
            _context.HealthRecords.Add(record);
            await _context.SaveChangesAsync();
        }

        // Удалить запись
        public async Task DeleteRecordAsync(int id, string userId)
        {
            var record = await _context.HealthRecords
                .FirstOrDefaultAsync(r => r.Id == id && r.UserId == userId);

            if (record != null)
            {
                _context.HealthRecords.Remove(record);
                await _context.SaveChangesAsync();
            }
        }
    }
}
