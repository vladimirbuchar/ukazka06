﻿using Core.Base.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Tables.Edu.Certificate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EduRepository.CertificateRepository
{
    public class CertificateRepository(EduDbContext dbContext, IMemoryCache memoryCache) : BaseRepository<CertificateDbo>(dbContext, memoryCache), ICertificateRepository
    {
        public override CertificateDbo GetEntity(Guid id)
        {
            return _dbContext.Set<CertificateDbo>()
                .Include(x => x.CertificateTranslations.Where(x => x.IsDeleted == false))
                .ThenInclude(x => x.Culture).FirstOrDefault(x => x.Id == id);
        }

        public override HashSet<CertificateDbo> GetEntities(bool deleted, Expression<Func<CertificateDbo, bool>> predicate = null)
        {
            return [.. _dbContext.Set<CertificateDbo>()
                .Where(x => x.IsDeleted == deleted)
                .Where(predicate)
                .Include(x => x.CertificateTranslations.Where(x => x.IsDeleted == false))
                .ThenInclude(x => x.Culture)];
        }

        public override Guid GetOrganizationId(Guid objectId)
        {
            return _dbContext.Set<CertificateDbo>().FirstOrDefault(x => x.Id == objectId).OrganizationId;
        }
    }
}
