namespace ProductStore.Infrastructure.Repositories.BaseReposiory;

public interface IBase<TRepo>
{
    public ValueTask<TRepo> InsertAsync(TRepo repo);
    public ValueTask<TRepo> UpdateAsync(Guid id, TRepo repo);
    public ValueTask<TRepo> DeleteAsync(Guid id);
    public ValueTask<TRepo?> SelectByNameAsync(string Name);
    public ValueTask<TRepo?> SelectByIdAsync(Guid id);
    public ValueTask<IList<TRepo>> SelectAllAsync();
}
