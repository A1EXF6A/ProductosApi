using ProductosApi.Models;

namespace ProductosApi.Services;

public class ProductoService
{
    private readonly List<Producto> _productos =
        [
            new Producto { Id = 1, Nombre = "Laptop", Precio = 1500, Disponible = true },
            new Producto { Id = 2, Nombre = "Mouse", Precio = 25, Disponible = true },
            new Producto { Id = 3, Nombre = "Teclado", Precio = 45, Disponible = false }
        ];

    public List<Producto> GetAll() => _productos;
    public Producto? GetById(int id) => _productos.FirstOrDefault(p => p.Id == id);

    public Producto Add(Producto producto)
    {
        producto.Id = _productos.Max(p => p.Id) + 1;
        _productos.Add(producto);
        return producto;
    }

    public bool Update(int id, Producto producto)
    {
        var existing = _productos.FirstOrDefault(p => p.Id == id);
        if (existing is null) return false;

        existing.Nombre = producto.Nombre;
        existing.Precio = producto.Precio;
        existing.Disponible = producto.Disponible;
        return true;
    }

    public bool Delete(int id)
    {
        var producto = _productos.FirstOrDefault(p => p.Id == id);
        if (producto is null) return false;

        _productos.Remove(producto);
        return true;
    }
}
