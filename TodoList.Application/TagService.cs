using System;
using System.Threading.Tasks;
using AutoMapper;
using TodoList.Application.Contratos;
using TodoList.Application.Dtos;
using TodoList.Domain;
using TodoList.Persistence.Contratos;

namespace TodoList.Application
{
    public class TagService : ITagService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly ITagPersist _tagPersist;
        private readonly IMapper _mapper;

        public TagService(
            IGeralPersist geralPersist, 
            ITagPersist tagPersist,
            IMapper mapper
        )
        {
            _geralPersist = geralPersist;
            _tagPersist = tagPersist;
            _mapper = mapper;
        }

        public async Task<TagDto> AddTag(TagDto model)
        {
            try
            {
                var tag = _mapper.Map<Tag>(model);
                _geralPersist.Add(tag);

                if (await _geralPersist.SaveChangesAsync())
                {
                    var tagRetorno = await _tagPersist.GetTagByIdAsync(tag.Id);
                    return _mapper.Map<TagDto>(tagRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<TagDto> UpdateTag(int tagId, TagDto model)
        {
            try
            {
                var tag = await _tagPersist.GetTagByIdAsync(tagId);
                if (tag == null) return null;

                model.Id = tag.Id;

                _mapper.Map(model, tag);
                _geralPersist.Update(tag);

                if (await _geralPersist.SaveChangesAsync())
                {
                    var tagRetorno = await _tagPersist.GetTagByIdAsync(tag.Id);
                    return _mapper.Map<TagDto>(tagRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DeleteTag(int tagId)
        {
            try
            {
                var tag = await _tagPersist.GetTagByIdAsync(tagId);
                if (tag == null) throw new Exception("Erro ao excluir tag. Tag não encontrado!");

                _geralPersist.Delete<Tag>(tag);

                return await _geralPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<TagDto[]> GetAllTagsAsync()
        {
            try
            {
                var tags = await _tagPersist.GetAllTagsAsync();
                if (tags == null) return null;

                var resultado = _mapper.Map<TagDto[]>(tags);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TagDto> GetTagByIdAsync(int tagId)
        {
            try
            {
                var tag = await _tagPersist.GetTagByIdAsync(tagId);
                if (tag == null) return null;

                var resultado = _mapper.Map<TagDto>(tag);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}