using ComputerAccessories.Model;

namespace ComputerAccessories.IServices
{
    public interface IMouseService
    {
        public Task<IEnumerable<Mouse>> GetAllMouseAsync();
        public Task<Mouse> GetMouseByIdAsync(int id);
        public Task<Mouse> CreateMouseAsync(Mouse mouse);
        public Task<Mouse> UpdateMouseAsync(int id, Mouse mouse);
        public Task<bool>  DeleteMouseAsync(int id);
    }
}
