﻿using System;
using Core.Base.Repository;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Tables.Edu.CourseTable;

namespace EduRepository.CourseTableRepository
{
    public class CourseTableRepository(EduDbContext dbContext, IMemoryCache memoryCache) : BaseRepository<CourseTableDbo>(dbContext, memoryCache), ICourseTableRepository
    {
        public void UpdateActualTable(Guid courseTermid, string img)
        {
            SaveDataToCache(courseTermid.ToString(), img, DateTime.Now.AddHours(1));
        }

        public string GetActualTable(Guid courseTermid)
        {
            return GetFirstDataFromCache<string>(courseTermid.ToString());
        }
    }
}
