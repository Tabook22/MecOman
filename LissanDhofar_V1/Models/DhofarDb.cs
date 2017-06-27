﻿using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LissanDhofar_V1.Models
{
    public class DhofarDb:DbContext
    {
        public DhofarDb ():base("name=myConnection")
        {

        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Article>Articles { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<UploadedFile> UploadedFiles { get; set; }
        public DbSet<Conference> Conferences { get; set; }
        public DbSet<conInfo> conInfos { get; set; }
        public DbSet<confile> confiles { set; get; }
        public DbSet<contact> contacts { set; get; }
        public DbSet<ConfVideo> ConfVideos { get; set; }
    }
}