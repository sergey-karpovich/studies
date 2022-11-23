﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SolarCoffee.Services.InventoryService;
using SolarCoffee.Web.Serialization;
using SolarCoffee.Web.ViewModels;

namespace SolarCoffee.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _inventoryService;
        private readonly ILogger<InventoryController> _logger;
        public InventoryController(IInventoryService inventoryService, ILogger<InventoryController> logger)
        {
            _inventoryService = inventoryService;
            _logger = logger;
        }

        [HttpGet("/api/inventory")]
        public ActionResult GetCurrentInventory()
        {
            _logger.LogInformation("Getting all inventory...");

            var inventory = _inventoryService.GetCurrentInventory()
                .Select(pi => new ProductInventoryModel {
                    Id= pi.Id,
                    Product = ProductMapper.SerializeProductModel(pi.Product),
                    IdealQuantity = pi.IdealQuantity,
                    QuantityOnHand=pi.QuantityOnHand 
                })
                .OrderBy(inv => inv.Product.Name)
                .ToList();

            return Ok(inventory);
        }


        [HttpPatch("/api/inventory")]
        public ActionResult UpdateInventory([FromBody] ShipmentModel shipment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            _logger.LogInformation(
                "Updating inventory for" +
                $"{shipment.ProductId} - " +
                $"Adjustment: {shipment.Adjustment}"
                );

            var id = shipment.ProductId;
            var adjustment = shipment.Adjustment;
            var inventory = _inventoryService.UpdateUnitsAvailable(id, adjustment);

            return Ok(inventory);
        }

        [HttpGet("/api/inventory/snapshot")]
        public ActionResult GetSnapshotHistory()
        {
            /**
             * {
             * timeline: [1,2,3 .. n],
             * inventory: [{ id: 1, qty: [43,21,32 .. n]}, { id: 2, qty: [43, 12, 43 ..n]}]
             * }
             * */
            _logger.LogInformation("Getting snapshot history");
            try
            {
                var snapshotHistory = _inventoryService.GetSnapshotHistory();

                // Get distinct points in time a snapshot was collected
                var timelineMarkers = snapshotHistory
                    .Select(t => t.SnapshotTime)
                    .Distinct()
                    .ToList();

                var snapshots = snapshotHistory
                    .GroupBy(hist => hist.Product, hist => hist.QuantityOnHand,
                    (key, g) => new ProductInventorySnapshotModel
                    {
                        ProductId = key.Id,
                        QuantityOnHand = g.ToList()
                    })
                    .OrderBy(hist => hist.ProductId)
                    .ToList();

                var viewModel = new SnapshotResponse
                {
                    Timeline = timelineMarkers,
                    ProductInventorySnapshots = snapshots
                };
                return Ok(viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error getting snapshot history.");
                _logger.LogError(ex.StackTrace);
                return BadRequest("error retrieving history");
            }

        }
    }
}
