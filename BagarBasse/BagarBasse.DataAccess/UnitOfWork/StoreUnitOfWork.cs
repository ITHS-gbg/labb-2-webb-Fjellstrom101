using BagarBasse.DataAccess;
using BagarBasse.Server.Repositories;
using BagarBasse.Shared.Models;

namespace BagarBasse.Server.UnitOfWork;

public class StoreUnitOfWork : IUnitOfWork
{
    private readonly DataContext _context;

    private GenericRepository<Product> _productRepository;
    private GenericRepository<ProductType> _productTypeRepository;
    private GenericRepository<ProductVariant> _productVariantRepository;
    private GenericRepository<Category> _categoryRepository;
    private GenericRepository<User> _userRepository;
    private GenericRepository<UserInfo> _userInfoRepository;
    private GenericRepository<Order> _orderRepository;
    private GenericRepository<OrderItem> _orderItemRepository;

    public StoreUnitOfWork(DataContext context)
    {
        _context = context;
    }

    public GenericRepository<Product> ProductRepository
    {
        get { return _productRepository ??= new GenericRepository<Product>(_context); }
    }
    public GenericRepository<ProductType> ProductTypeRepository
    {
        get { return _productTypeRepository ??= new GenericRepository<ProductType>(_context); }
    }
    public GenericRepository<ProductVariant> ProductVariantRepository
    {
        get { return _productVariantRepository ??= new GenericRepository<ProductVariant>(_context); }
    }
    public GenericRepository<Category> CategoryRepository
    {
        get { return _categoryRepository ??= new GenericRepository<Category>(_context); }
    }
    public GenericRepository<User> UserRepository
    {
        get { return _userRepository ??= new GenericRepository<User>(_context); }
    }
    public GenericRepository<UserInfo> UserInfoRepository
    {
        get { return _userInfoRepository ??= new GenericRepository<UserInfo>(_context); }
    }
    public GenericRepository<Order> OrderRepository
    {
        get { return _orderRepository ??= new GenericRepository<Order>(_context); }
    }
    public GenericRepository<OrderItem> OrderItemRepository
    {
        get { return _orderItemRepository ??= new GenericRepository<OrderItem>(_context); }
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    private bool disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
        this.disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}