﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Project.Data;

#nullable disable

namespace Project.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250221095210_ChangeCreatedByToGuid")]
    partial class ChangeCreatedByToGuid
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Project.Models.News", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("news_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("content");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid")
                        .HasColumnName("created_by");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<DateTime?>("DatePublish")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date_publish");

                    b.Property<int?>("DeletedBy")
                        .HasColumnType("integer")
                        .HasColumnName("deleted_by");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("news_desc");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean")
                        .HasColumnName("is_active");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<string>("MetaKeyword")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("meta_keyword");

                    b.Property<string>("MetaTitle")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("meta_title");

                    b.Property<int?>("ModifiedBy")
                        .HasColumnType("integer")
                        .HasColumnName("modified_by");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("modified_date");

                    b.Property<int?>("NewsListId")
                        .HasColumnType("integer")
                        .HasColumnName("news_list_id");

                    b.Property<int?>("NewsStatus")
                        .HasColumnType("integer")
                        .HasColumnName("news_status");

                    b.Property<int?>("NewsType")
                        .HasColumnType("integer")
                        .HasColumnName("news_type");

                    b.Property<string>("Picture")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("picture");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("news_title");

                    b.Property<int>("Views")
                        .HasColumnType("integer")
                        .HasColumnName("views");

                    b.HasKey("Id");

                    b.ToTable("news", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
