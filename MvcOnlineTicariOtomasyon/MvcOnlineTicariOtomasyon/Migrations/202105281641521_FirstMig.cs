namespace MvcOnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminId = c.Int(nullable: false, identity: true),
                        KullaniciAd = c.String(maxLength: 20, unicode: false),
                        Sifre = c.String(maxLength: 20, unicode: false),
                        Yetki = c.String(maxLength: 1, fixedLength: true, unicode: false),
                    })
                .PrimaryKey(t => t.AdminId);
            
            CreateTable(
                "dbo.Departmen",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        DepartmentAd = c.String(maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Personels",
                c => new
                    {
                        PersonelId = c.Int(nullable: false, identity: true),
                        PersonelAd = c.String(maxLength: 30, unicode: false),
                        PersonelSoyad = c.String(maxLength: 30, unicode: false),
                        PersonelFotograf = c.String(maxLength: 250, unicode: false),
                        Departman_DepartmentId = c.Int(),
                    })
                .PrimaryKey(t => t.PersonelId)
                .ForeignKey("dbo.Departmen", t => t.Departman_DepartmentId)
                .Index(t => t.Departman_DepartmentId);
            
            CreateTable(
                "dbo.SatisHarekets",
                c => new
                    {
                        SatisId = c.Int(nullable: false, identity: true),
                        SatisTarih = c.DateTime(nullable: false),
                        Adet = c.Int(nullable: false),
                        Fiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ToplamTutar = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Musteriler_MusteriId = c.Int(),
                        Personel_PersonelId = c.Int(),
                        Urun_UrunId = c.Int(),
                    })
                .PrimaryKey(t => t.SatisId)
                .ForeignKey("dbo.Musterilers", t => t.Musteriler_MusteriId)
                .ForeignKey("dbo.Personels", t => t.Personel_PersonelId)
                .ForeignKey("dbo.Uruns", t => t.Urun_UrunId)
                .Index(t => t.Musteriler_MusteriId)
                .Index(t => t.Personel_PersonelId)
                .Index(t => t.Urun_UrunId);
            
            CreateTable(
                "dbo.Musterilers",
                c => new
                    {
                        MusteriId = c.Int(nullable: false, identity: true),
                        MusteriAd = c.String(maxLength: 30, unicode: false),
                        MusteriSoyad = c.String(maxLength: 30, unicode: false),
                        MusteriSehir = c.String(maxLength: 20, unicode: false),
                        MusteriEmail = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.MusteriId);
            
            CreateTable(
                "dbo.Uruns",
                c => new
                    {
                        UrunId = c.Int(nullable: false, identity: true),
                        UrunAd = c.String(maxLength: 30, unicode: false),
                        UrunMarka = c.String(maxLength: 30, unicode: false),
                        UrunStok = c.Short(nullable: false),
                        UrunAlisFiyatı = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UrunSatisFiyatı = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UrunDurum = c.Boolean(nullable: false),
                        UrunFotograf = c.String(maxLength: 250, unicode: false),
                        Kategori_KategoriId = c.Int(),
                    })
                .PrimaryKey(t => t.UrunId)
                .ForeignKey("dbo.Kategoris", t => t.Kategori_KategoriId)
                .Index(t => t.Kategori_KategoriId);
            
            CreateTable(
                "dbo.Kategoris",
                c => new
                    {
                        KategoriId = c.Int(nullable: false, identity: true),
                        KategoriAd = c.String(maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.KategoriId);
            
            CreateTable(
                "dbo.FaturaKalems",
                c => new
                    {
                        FaturaKalemId = c.Int(nullable: false, identity: true),
                        Aciklama = c.String(maxLength: 100, unicode: false),
                        Miktar = c.Int(nullable: false),
                        BirimFiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Tutar = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Faturalar_FaturaId = c.Int(),
                    })
                .PrimaryKey(t => t.FaturaKalemId)
                .ForeignKey("dbo.Faturalars", t => t.Faturalar_FaturaId)
                .Index(t => t.Faturalar_FaturaId);
            
            CreateTable(
                "dbo.Faturalars",
                c => new
                    {
                        FaturaId = c.Int(nullable: false, identity: true),
                        FaturaSiraNo = c.String(maxLength: 6, unicode: false),
                        FaturaTarih = c.DateTime(nullable: false),
                        FaturaVergiDairesi = c.String(maxLength: 30, unicode: false),
                        FaturaSaat = c.DateTime(nullable: false),
                        FaturaTeslimEden = c.String(maxLength: 30, unicode: false),
                        FaturaTeslimAlan = c.String(maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.FaturaId);
            
            CreateTable(
                "dbo.Giderlers",
                c => new
                    {
                        GiderId = c.Int(nullable: false, identity: true),
                        GiderAciklama = c.String(maxLength: 100, unicode: false),
                        GiderTarih = c.DateTime(nullable: false),
                        GiderTutar = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.GiderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FaturaKalems", "Faturalar_FaturaId", "dbo.Faturalars");
            DropForeignKey("dbo.SatisHarekets", "Urun_UrunId", "dbo.Uruns");
            DropForeignKey("dbo.Uruns", "Kategori_KategoriId", "dbo.Kategoris");
            DropForeignKey("dbo.SatisHarekets", "Personel_PersonelId", "dbo.Personels");
            DropForeignKey("dbo.SatisHarekets", "Musteriler_MusteriId", "dbo.Musterilers");
            DropForeignKey("dbo.Personels", "Departman_DepartmentId", "dbo.Departmen");
            DropIndex("dbo.FaturaKalems", new[] { "Faturalar_FaturaId" });
            DropIndex("dbo.Uruns", new[] { "Kategori_KategoriId" });
            DropIndex("dbo.SatisHarekets", new[] { "Urun_UrunId" });
            DropIndex("dbo.SatisHarekets", new[] { "Personel_PersonelId" });
            DropIndex("dbo.SatisHarekets", new[] { "Musteriler_MusteriId" });
            DropIndex("dbo.Personels", new[] { "Departman_DepartmentId" });
            DropTable("dbo.Giderlers");
            DropTable("dbo.Faturalars");
            DropTable("dbo.FaturaKalems");
            DropTable("dbo.Kategoris");
            DropTable("dbo.Uruns");
            DropTable("dbo.Musterilers");
            DropTable("dbo.SatisHarekets");
            DropTable("dbo.Personels");
            DropTable("dbo.Departmen");
            DropTable("dbo.Admins");
        }
    }
}
