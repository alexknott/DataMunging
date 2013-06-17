using System;
using System.Collections.Generic;
using CommonLibrary;

namespace FootballData
{
    public interface ITeamFactory
    {
        Team[] GetTeams();
    }

    public class TeamFactory : ITeamFactory
    {
        private readonly FileSystemFacade _fileSystemFacade;

        private readonly string _path = @"E:\users\PHAT\Documents\Visual Studio 11\Projects\DataMunging\FootballData.Tests\football.dat";

        public TeamFactory(FileSystemFacade fileSystemFacade)
        {
            _fileSystemFacade = fileSystemFacade;
        }

        public Team[] GetTeams()
        {
            List<Team> teams = new List<Team>();
            string[] lines = _fileSystemFacade.ReadAllLines(_path);


            foreach (var line in lines)
            {
                string[] parts = line.Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);
                
                if (parts.Length != 10)
                    continue;

                string name = parts[1];
                int goalsFor;
                int goalsAgainst;

                if (!int.TryParse(parts[6], out goalsFor))
                    continue;

                if (!int.TryParse(parts[8], out goalsAgainst))
                    continue;

                teams.Add(new Team(name, goalsFor, goalsAgainst));
            }

            return teams.ToArray();
        }
    }
}