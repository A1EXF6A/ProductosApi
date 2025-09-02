using ProductosApi.Models;

namespace ProductosApi.Services;

public class ProductoService
{
    private List<Producto> _productos =
        [
            new Producto { Id = 1, Nombre = "Laptop", Precio = 1500, Disponible = true },
            new Producto { Id = 2, Nombre = "Mouse", Precio = 25, Disponible = true },
            new Producto { Id = 3, Nombre = "Teclado", Precio = 45, Disponible = false }
        ];

}
