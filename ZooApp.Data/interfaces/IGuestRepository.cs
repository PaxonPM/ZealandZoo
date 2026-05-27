namespace ZooApp.Data.interfaces;

/// <summary>
/// Interface for the Guest repository, which extends both the IUserRepository and ICreateUserRepository interfaces.
/// </summary>
public interface IGuestRepository : IUserRepository, ICreateUserRepository { }