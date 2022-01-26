﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using YoutubeDownloader.Persistence;

namespace YoutubeDownloader.Persistence.Migrations
{
    [DbContext(typeof(YoutubeDownloaderContext))]
    [Migration("20220125223112_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.13");

            modelBuilder.Entity("YoutubeDownloader.Common.Models.BatchUpload", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("id");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created");

                    b.HasKey("Id");

                    b.ToTable("batch_upload");
                });

            modelBuilder.Entity("YoutubeDownloader.Common.Models.BatchUploadLink", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<string>("BatchUploadId")
                        .HasColumnType("longtext")
                        .HasColumnName("batch_upload_id");

                    b.Property<string>("VideoId")
                        .HasColumnType("longtext")
                        .HasColumnName("video_id");

                    b.HasKey("Id");

                    b.ToTable("batch_upload_link");
                });

            modelBuilder.Entity("YoutubeDownloader.Common.Models.VideoMeta", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("id");

                    b.Property<float>("Duration")
                        .HasColumnType("float")
                        .HasColumnName("duration");

                    b.Property<DateTime>("MetaCreated")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("meta_created");

                    b.Property<string>("UploaderName")
                        .HasColumnType("longtext")
                        .HasColumnName("uploader_name");

                    b.Property<string>("VideoTitle")
                        .HasColumnType("longtext")
                        .HasColumnName("video_title");

                    b.HasKey("Id");

                    b.ToTable("video_meta");
                });

            modelBuilder.Entity("YoutubeDownloader.Common.Models.VideoMetaFormat", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<long>("FileSize")
                        .HasColumnType("bigint")
                        .HasColumnName("file_size");

                    b.Property<string>("FileType")
                        .HasColumnType("longtext")
                        .HasColumnName("file_type");

                    b.Property<long>("FormatId")
                        .HasColumnType("bigint")
                        .HasColumnName("format_id");

                    b.Property<string>("Quality")
                        .HasColumnType("longtext")
                        .HasColumnName("video_quality");

                    b.Property<string>("VideoId")
                        .HasColumnType("longtext")
                        .HasColumnName("video_id");

                    b.HasKey("Id");

                    b.ToTable("video_meta_format");
                });
#pragma warning restore 612, 618
        }
    }
}
