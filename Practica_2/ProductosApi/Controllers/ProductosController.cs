using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductosApi.Data;
using ProductosApi.Models;

namespace ProductosApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ILogger<ProductosController> _logger;

        public ProductosController(AppDbContext context, ILogger<ProductosController> logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Obtener todos los productos
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductos()
        {
            _logger.LogInformation("Obteniendo lista de productos");
            var productos = await _context.Productos.ToListAsync();
            return Ok(productos);
        }

        /// <summary>
        /// Obtener un producto específico por ID
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Producto>> GetProducto(int id)
        {
            _logger.LogInformation($"Obteniendo producto con ID {id}");
            var producto = await _context.Productos.FindAsync(id);

            if (producto == null)
            {
                _logger.LogWarning($"Producto con ID {id} no encontrado");
                return NotFound(new { message = $"El producto con ID {id} no existe." });
            }

            return Ok(producto);
        }

        /// <summary>
        /// Crear un nuevo producto
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Producto>> PostProducto(Producto producto)
        {
            if (string.IsNullOrWhiteSpace(producto.Nombre))
            {
                return BadRequest(new { message = "El nombre del producto es requerido." });
            }

            if (producto.Precio < 0)
            {
                return BadRequest(new { message = "El precio no puede ser negativo." });
            }

            if (producto.Stock < 0)
            {
                return BadRequest(new { message = "El stock no puede ser negativo." });
            }

            producto.FechaCreacion = DateTime.UtcNow;
            producto.FechaActualizacion = DateTime.UtcNow;

            try
            {
                _context.Productos.Add(producto);
                await _context.SaveChangesAsync();

                _logger.LogInformation($"Nuevo producto creado con ID {producto.Id}");
                return CreatedAtAction(nameof(GetProducto), new { id = producto.Id }, producto);
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError($"Error al crear producto: {ex.Message}");
                return BadRequest(new { message = "Ya existe un producto con este nombre." });
            }
        }

        /// <summary>
        /// Actualizar un producto existente
        /// </summary>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutProducto(int id, Producto producto)
        {
            if (id != producto.Id)
            {
                return BadRequest(new { message = "El ID en la URL no coincide con el del producto." });
            }

            var productoExistente = await _context.Productos.FindAsync(id);
            if (productoExistente == null)
            {
                return NotFound(new { message = $"El producto con ID {id} no existe." });
            }

            if (string.IsNullOrWhiteSpace(producto.Nombre))
            {
                return BadRequest(new { message = "El nombre del producto es requerido." });
            }

            if (producto.Precio < 0)
            {
                return BadRequest(new { message = "El precio no puede ser negativo." });
            }

            if (producto.Stock < 0)
            {
                return BadRequest(new { message = "El stock no puede ser negativo." });
            }

            productoExistente.Nombre = producto.Nombre;
            productoExistente.Descripcion = producto.Descripcion;
            productoExistente.Precio = producto.Precio;
            productoExistente.Stock = producto.Stock;
            productoExistente.FechaActualizacion = DateTime.UtcNow;

            try
            {
                _context.Productos.Update(productoExistente);
                await _context.SaveChangesAsync();

                _logger.LogInformation($"Producto con ID {id} actualizado");
                return Ok(new { message = "Producto actualizado exitosamente", producto = productoExistente });
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError($"Error al actualizar producto: {ex.Message}");
                return BadRequest(new { message = "Error al actualizar el producto." });
            }
        }

        /// <summary>
        /// Eliminar un producto
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound(new { message = $"El producto con ID {id} no existe." });
            }

            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();

            _logger.LogInformation($"Producto con ID {id} eliminado");
            return Ok(new { message = "Producto eliminado exitosamente", id = id });
        }

        /// <summary>
        /// Búsqueda de productos por nombre
        /// </summary>
        [HttpGet("buscar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Producto>>> BuscarProductos(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                return BadRequest(new { message = "El término de búsqueda es requerido." });
            }

            var productos = await _context.Productos
                .Where(p => p.Nombre.Contains(nombre))
                .ToListAsync();

            _logger.LogInformation($"Búsqueda de productos con término '{nombre}' encontró {productos.Count} resultados");
            return Ok(productos);
        }
    }
}
