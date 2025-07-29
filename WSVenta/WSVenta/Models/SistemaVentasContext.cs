using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WSVenta.Models;

public partial class SistemaVentasContext : DbContext
{
    public SistemaVentasContext()
    {
    }

    public SistemaVentasContext(DbContextOptions<SistemaVentasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<ClientCard> ClientCards { get; set; }

    public virtual DbSet<DisplayLocation> DisplayLocations { get; set; }

    public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductCategory> ProductCategories { get; set; }

    public virtual DbSet<ProductImage> ProductImages { get; set; }

    public virtual DbSet<Promotion> Promotions { get; set; }

    public virtual DbSet<PromotionType> PromotionTypes { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<SaleDetail> SaleDetails { get; set; }

    public virtual DbSet<SaleStatus> SaleStatuses { get; set; }

    public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }

    public virtual DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost; Database=SistemaVentas; Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasIndex(e => e.IdClient, "UQ_Addresses_Id_Client").IsUnique();

            entity.Property(e => e.AddressFloor)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("address_floor");
            entity.Property(e => e.AddressNumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("address_number");
            entity.Property(e => e.AddressStreet)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("address_street");
            entity.Property(e => e.City)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("country");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.IdClient).HasColumnName("id_client");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.LastUpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("last_updated_at");
            entity.Property(e => e.PostalCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("postal_code");
            entity.Property(e => e.StateProvince)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("state_province");

            entity.HasOne(d => d.IdClientNavigation).WithOne(p => p.Address)
                .HasForeignKey<Address>(d => d.IdClient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Addresses_Clients");
        });

        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasIndex(e => e.BrandName, "UQ_Brands_Brand_Name").IsUnique();

            entity.Property(e => e.BrandName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("brand_name");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.LastUpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("last_updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.Brands)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("FK_Brands_Users");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasIndex(e => new { e.DocumentType, e.DocumentNumber }, "UQ_Clients_Document").IsUnique();

            entity.HasIndex(e => e.Email, "UQ_Clients_Email").IsUnique();

            entity.HasIndex(e => e.IdUser, "UQ_Clients_Id_User").IsUnique();

            entity.HasIndex(e => new { e.PhoneCode, e.PhoneNumber }, "UQ_Clients_Phone").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.BirthDate).HasColumnName("birth_date");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.DocumentNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("document_number");
            entity.Property(e => e.DocumentType)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("document_type");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("last_name");
            entity.Property(e => e.LastUpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("last_updated_at");
            entity.Property(e => e.PhoneCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("phone_code");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone_number");

            entity.HasOne(d => d.IdUserNavigation).WithOne(p => p.Client)
                .HasForeignKey<Client>(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Clients_Users");
        });

        modelBuilder.Entity<ClientCard>(entity =>
        {
            entity.HasIndex(e => e.CardToken, "Index_ClientCards_Card_Token").IsUnique();

            entity.Property(e => e.CardToken)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("card_token");
            entity.Property(e => e.CardType)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("card_type");
            entity.Property(e => e.CardholderName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("cardholder_name");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.ExpirationMonth).HasColumnName("expiration_month");
            entity.Property(e => e.ExpirationYear).HasColumnName("expiration_year");
            entity.Property(e => e.IdClient).HasColumnName("id_client");
            entity.Property(e => e.IsDefault)
                .HasDefaultValue(true)
                .HasColumnName("is_default");
            entity.Property(e => e.LastFourDigits)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("last_four_digits");
            entity.Property(e => e.LastUpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("last_updated_at");

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.ClientCards)
                .HasForeignKey(d => d.IdClient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ClientCards_Clients");
        });

        modelBuilder.Entity<DisplayLocation>(entity =>
        {
            entity.HasIndex(e => e.LocationName, "Index_DisplayLocations_Location_Name").IsUnique();

            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.LocationName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("location_name");
        });

        modelBuilder.Entity<PaymentMethod>(entity =>
        {
            entity.ToTable("PaymentMethods ");

            entity.HasIndex(e => e.MethodName, "UQ_PaymentMethods _Method_Name");

            entity.Property(e => e.IsOnline)
                .HasDefaultValue(true)
                .HasColumnName("is_online");
            entity.Property(e => e.MethodName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("method_name ");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasIndex(e => e.IdBrand, "UQ_Products_Id_Brand").IsUnique();

            entity.HasIndex(e => e.IdCategory, "UQ_Products_Id_Category").IsUnique();

            entity.HasIndex(e => e.Barcode, "UQ_Products_Id_Category_Barcode").IsUnique();

            entity.HasIndex(e => e.Sku, "UQ_Products_Id_Category_Sku").IsUnique();

            entity.HasIndex(e => e.ProductName, "UQ_Products_Id_Product_Name").IsUnique();

            entity.Property(e => e.Barcode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("barcode ");
            entity.Property(e => e.CostPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("cost_price");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrentSalesPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("current_sales_price");
            entity.Property(e => e.CurrentStock).HasColumnName("current_stock");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.IdBrand).HasColumnName("id_brand");
            entity.Property(e => e.IdCategory).HasColumnName("id_category");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.LastUpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("last_updated_at");
            entity.Property(e => e.MinimumStock).HasColumnName("minimum_stock");
            entity.Property(e => e.ProductName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("product_name");
            entity.Property(e => e.Sku)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("sku ");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.IdBrandNavigation).WithOne(p => p.Product)
                .HasForeignKey<Product>(d => d.IdBrand)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_Brands");

            entity.HasOne(d => d.IdCategoryNavigation).WithOne(p => p.Product)
                .HasForeignKey<Product>(d => d.IdCategory)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_ProductCategories");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("FK_Products_Users");
        });

        modelBuilder.Entity<ProductCategory>(entity =>
        {
            entity.HasIndex(e => e.CategoryName, "UQ_ProductCategories_Category_Name").IsUnique();

            entity.Property(e => e.CategoryName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("category_name");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.LastUpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("last_updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.ProductCategories)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("FK_ProductCategories_Users");
        });

        modelBuilder.Entity<ProductImage>(entity =>
        {
            entity.Property(e => e.AltText)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("alt_text");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.DisplayOrder).HasColumnName("display_order");
            entity.Property(e => e.FileName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("file_name");
            entity.Property(e => e.IdProduct).HasColumnName("id_product");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("image_url");
            entity.Property(e => e.IsMainImage).HasColumnName("is_main_image");
            entity.Property(e => e.LastUpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("last_updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.ProductImages)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductImages_Products");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.ProductImages)
                .HasForeignKey(d => d.UpdatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductImages_Users");
        });

        modelBuilder.Entity<Promotion>(entity =>
        {
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.DisplayOrder).HasColumnName("display_order");
            entity.Property(e => e.EndDate)
                .HasColumnType("datetime")
                .HasColumnName("end_date");
            entity.Property(e => e.IdDisplayLocation).HasColumnName("id_display_location");
            entity.Property(e => e.IdPromotionType).HasColumnName("id_promotion_type");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("image_url");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.LastUpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("last_updated_at");
            entity.Property(e => e.StartDate)
                .HasColumnType("datetime")
                .HasColumnName("start_date");
            entity.Property(e => e.TargetUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("target_url");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("title");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.IdDisplayLocationNavigation).WithMany(p => p.Promotions)
                .HasForeignKey(d => d.IdDisplayLocation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Promotions_DisplayLocations_1");

            entity.HasOne(d => d.IdPromotionTypeNavigation).WithMany(p => p.Promotions)
                .HasForeignKey(d => d.IdPromotionType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Promotions_PromotionTypes");
        });

        modelBuilder.Entity<PromotionType>(entity =>
        {
            entity.HasIndex(e => e.TypeName, "Index_PromotionTypes_Type_Name").IsUnique();

            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.TypeName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("type_name");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasIndex(e => e.IdPaymentMethod, "UQ_Sales_Id_Payment_Method").IsUnique();

            entity.HasIndex(e => e.IdSaleStatus, "UQ_Sales_Id_Sale_status").IsUnique();

            entity.HasIndex(e => e.IdClient, "UQ_Sales_Id_client").IsUnique();

            entity.HasIndex(e => e.PurchaseOrderNumber, "UQ_Sales_Pucharse_Order_Number").IsUnique();

            entity.Property(e => e.ActualShippingDate).HasColumnName("actual_shipping_date");
            entity.Property(e => e.Comments)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("comments");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.DiscountAmount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("discount_amount");
            entity.Property(e => e.EstimatedShippingDate).HasColumnName("estimated_shipping_date");
            entity.Property(e => e.IdClient).HasColumnName("id_client");
            entity.Property(e => e.IdPaymentMethod).HasColumnName("id_payment_method");
            entity.Property(e => e.IdSaleStatus).HasColumnName("id_sale_status");
            entity.Property(e => e.LastUpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("last_updated_at");
            entity.Property(e => e.PurchaseOrderNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("purchase_order_number");
            entity.Property(e => e.SaleDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("sale_date");
            entity.Property(e => e.SubtotalAmount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("subtotal_amount");
            entity.Property(e => e.TaxAmount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("tax_amount");
            entity.Property(e => e.TotalAmount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total_amount");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.IdClientNavigation).WithOne(p => p.Sale)
                .HasForeignKey<Sale>(d => d.IdClient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_Clients");

            entity.HasOne(d => d.IdPaymentMethodNavigation).WithOne(p => p.Sale)
                .HasForeignKey<Sale>(d => d.IdPaymentMethod)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_PaymentMethods ");

            entity.HasOne(d => d.IdSaleStatusNavigation).WithOne(p => p.Sale)
                .HasForeignKey<Sale>(d => d.IdSaleStatus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_SaleStatuses ");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.Sales)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("FK_Sales_Users");
        });

        modelBuilder.Entity<SaleDetail>(entity =>
        {
            entity.ToTable("SaleDetails ");

            entity.Property(e => e.IdProduct).HasColumnName("id_product");
            entity.Property(e => e.IdSale).HasColumnName("id_sale");
            entity.Property(e => e.LineDiscountAmount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("line_discount_amount");
            entity.Property(e => e.LineTaxAmount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("line_tax_amount");
            entity.Property(e => e.LineTotalAmount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("line_total_amount");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.UnitPriceAtSale)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("unit_price_at_sale");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.SaleDetails)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SaleDetails _Products");

            entity.HasOne(d => d.IdSaleNavigation).WithMany(p => p.SaleDetails)
                .HasForeignKey(d => d.IdSale)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SaleDetails _Sales");
        });

        modelBuilder.Entity<SaleStatus>(entity =>
        {
            entity.ToTable("SaleStatuses ");

            entity.HasIndex(e => e.StatusName, "UQ_SaleStatuses_Status_Name").IsUnique();

            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.StatusName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("status_name ");
        });

        modelBuilder.Entity<ShoppingCart>(entity =>
        {
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.IdClient).HasColumnName("id_client");
            entity.Property(e => e.LastUpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("last_updated_at");

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.ShoppingCarts)
                .HasForeignKey(d => d.IdClient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ShoppingCarts_Clients");
        });

        modelBuilder.Entity<ShoppingCartItem>(entity =>
        {
            entity.Property(e => e.AddedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("added_at ");
            entity.Property(e => e.IdCart).HasColumnName("id_cart");
            entity.Property(e => e.IdProduct).HasColumnName("id_product");
            entity.Property(e => e.Quantity).HasColumnName("quantity ");

            entity.HasOne(d => d.IdCartNavigation).WithMany(p => p.ShoppingCartItems)
                .HasForeignKey(d => d.IdCart)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ShoppingCartItems_ShoppingCarts");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.ShoppingCartItems)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ShoppingCartItems_Products_1");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasIndex(e => e.Email, "UQ_Users_Email").IsUnique();

            entity.HasIndex(e => e.Username, "UQ_Users_Username").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.IdRole).HasColumnName("id_role");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.LastUpdateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("lastUpdate_date");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password_hash");
            entity.Property(e => e.Salt)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("salt ");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("username ");

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdRole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_UserRoles");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasIndex(e => e.RoleName, "UQ_UserRoles_Role_Name").IsUnique();

            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("role_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
