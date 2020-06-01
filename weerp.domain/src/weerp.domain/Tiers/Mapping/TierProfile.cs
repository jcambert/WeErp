using AutoMapper;
using weerp.domain.tiers.Domain;
using weerp.domain.tiers.Dto;

using weerp.domain.tiers.Messages.Commands;
using weerp.domain.tiers.Messages.Events;

/// <summary>
/// This file was generated by the yeoman generator "generator-micros"
/// @author: Ambert Jean-Christophe
/// @email: jc.ambert@free.fr
/// @created_on: Sun May 31 2020 14:29:59 GMT+0200 (GMT+02:00)
/// </summary>
namespace weerp.domain.tiers.Mapping
{
    public class TierProfile:Profile
    {
        public TierProfile()
        {
            CreateMap<Tier, TierDto>();
            
            CreateMap<CreateTier, Tier>();
            CreateMap<CreateTier, TierCreated>();
            CreateMap<UpdateTier, TierUpdated>();
            CreateMap<DeleteTier, TierDeleted>();
            
        }
    }
}