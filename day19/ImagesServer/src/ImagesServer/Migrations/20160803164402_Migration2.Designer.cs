using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ImagesServer.Data;

namespace ImagesServer.Migrations
{
    [DbContext(typeof(ImagesContext))]
    [Migration("20160803164402_Migration2")]
    partial class Migration2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ImagesServer.Data.Images", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("image");

                    b.Property<string>("name");

                    b.Property<string>("platform");

                    b.HasKey("id");

                    b.ToTable("Images");
                });
        }
    }
}
