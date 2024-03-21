using ComputerAccessories.IRepositories;
using ComputerAccessories.IServices;
using ComputerAccessories.Model;

namespace ComputerAccessories.Services
{
    public class MouseService : IMouseService
    {
        private readonly IMouseRepository _mouseRepository;
        public MouseService(IMouseRepository mouseRepository)
        {
            this._mouseRepository = mouseRepository;
        }
        public async Task<Mouse> CreateMouseAsync(Mouse mouse)
        {
            return await _mouseRepository.CreateAsync(mouse);
        }

        public async Task<bool> DeleteMouseAsync(int id)
        {
            var mouseToBeDeleted = await _mouseRepository.GetByIdAsync(id);
            if (mouseToBeDeleted != null)
            {
                await _mouseRepository.DeleteAsync(id);
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Mouse>> GetAllMouseAsync()
        {
            var mouseList = await _mouseRepository.GetAllAsync();
            if(mouseList != null)
            {
                return mouseList;
            }
            return null;
        }

        public async Task<Mouse> GetMouseByIdAsync(int id)
        {
            var mouse = await _mouseRepository.GetByIdAsync(id);
            if(mouse != null)
            {
                return mouse;
            }
            return null;
        }

        public async Task<Mouse> UpdateMouseAsync(int id, Mouse mouse)
        {
            var oldMouse = await _mouseRepository.GetByIdAsync(id);
            if(oldMouse != null)
            {
                oldMouse.Name = mouse.Name;
                oldMouse.BrandId = mouse.BrandId;
                oldMouse.Price = mouse.Price;
                return await _mouseRepository.UpdateAsync(id, oldMouse);
            }
            return null;
        }
    }
}
