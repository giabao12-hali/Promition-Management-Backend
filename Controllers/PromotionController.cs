using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using promotion_net.DTO.Promotions;
using promotion_net.Services.Promotions.Interfaces;

namespace promotion_net.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class PromotionController : ControllerBase
    {
        private readonly IPromotionService _promotionService;
        public PromotionController(IPromotionService promotionService)
        {
            _promotionService = promotionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _promotionService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var promotion = await _promotionService.GetByIdAsync(id);
            if (promotion == null) return NotFound();
            return Ok(promotion);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePromotionDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var createdPromotion = await _promotionService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = createdPromotion.Id }, createdPromotion);
        }

        [HttpPost("apply")]
        public async Task<IActionResult> ApplyPromotion([FromBody] ApplyPromotionDto dto)
        {
            try
            {
                var finalPrice = await _promotionService.ApplyPromotionAsync(dto);
                return Ok(new { success = true, finalPrice });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        [HttpPost("add-products")]
        public async Task<IActionResult> AddProductsToPromotion([FromBody] AddPromotionToProducts dto)
        {
            try
            {
                var result = await _promotionService.AddProductsToPromotionAsync(dto);
                if (result)
                    return Ok(new { message = "Sản phẩm đã được thêm vào khuyến mãi thành công" });
                return BadRequest(new { message = "Thêm sản phẩm vào khuyến mãi thất bại" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdatePromotionDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var updatedPromotion = await _promotionService.UpdateAsync(id, dto);
            if (updatedPromotion == null) return NotFound();
            return Ok(updatedPromotion);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _promotionService.DeleteAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}