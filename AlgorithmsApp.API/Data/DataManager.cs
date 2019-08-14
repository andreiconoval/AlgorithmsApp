using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AlgorithmsApp.API.Models;
using System;
using System.Linq;
using AlgorithmsApp.API.Dtos;

namespace AlgorithmsApp.API.Data
{
    public class DataManager
    {
        private readonly DataContext _context;
        public DataManager(DataContext context)
        {
            _context = context;
        }

        // public DataManager()
        // {
        //     DbContextOptions<DataContext> options;
        //     string projectPath = AppDomain.CurrentDomain.BaseDirectory.Split(new String[] { @"bin\" }, StringSplitOptions.None)[0];
        //     IConfigurationRoot configuration = new ConfigurationBuilder()
        //                                             .SetBasePath(projectPath)
        //                                             .AddJsonFile("appsettings.json")
        //                                             .Build();
        //     string connectionString = configuration.GetConnectionString("DefaultConnection");
        //     _context = new DataContext(configuration);
        // }

        public async Task<List<Algorithm>> GetAlgorithmsAsync()
        {
            var algorithms = await _context.Algorithms.ToListAsync();
            return algorithms;
        }

        public async Task<Algorithm> GetAlgorithmAsync(string name)
        {
            var algorithms = await _context.Algorithms.FirstOrDefaultAsync(a => a.Name == name);
            return algorithms;
        }

        public async Task<bool> AddOrUpdateAlgorithm(string name)
        {
            try
            {
                var isAlgorithim = await _context.Algorithms.AnyAsync(m => m.Name == name);
                if (!isAlgorithim)
                {
                    var algorithm = new Algorithm()
                    {
                        Name = name,
                        Description = "Generated"
                    };
                    await _context.Algorithms.AddAsync(algorithm);
                    await _context.SaveChangesAsync();
                    return true;
                }
                else { return false; }

            }
            catch (Exception e)
            {
                throw e;
            }


        }

        public async Task<List<AlgStatistic>> GetAlgoritmsStatisticAsync()
        {
            try
            {
                List<AlgStatistic> statistics = await _context.AlgorithmStatistics
                            .Include("Algorithm")
                            .Include("MockData")
                            .GroupBy(p => p.AlgorithmId,
                                     (k, c) => new AlgStatistic()
                                     {
                                         AlgId = k,
                                         AlgName = c.Select(a => a.Algorithm.Name).FirstOrDefault(),
                                         Statistics = c.Select(cs => new Statistic()
                                         {
                                             Id = cs.Id,
                                             MockLength = cs.MockData.NumberOfElements,
                                             ExecutedTime = cs.ExecutedTime,
                                             Date = cs.Date
                                         }).Take(100).TakeLast(50).ToList()
                                     }
                                    ).ToListAsync();

                return statistics;
            }
            catch (Exception e) { throw new Exception(e.Message); };


        }

        public async Task<bool> AddAloritmStatisticAsync(AlgorithmStatistic algorithmsStatistic)
        {
            try
            {
                _context.AlgorithmStatistics.Add(algorithmsStatistic);
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<MockData>> GetMocks()
        {
            return await _context.MockDatas.ToListAsync();
        }

        public async Task<bool> GenerateMocks(string setOfMock, int numberOfElements)
        {

            try
            {
                var isMock = _context.MockDatas.Any(m => m.NumberOfElements == numberOfElements);
                if (!isMock)
                {
                    var mock = new MockData()
                    {
                        NumberOfElements = numberOfElements,
                        SetOfData = setOfMock
                    };

                    _context.MockDatas.Add(mock);
                    await _context.SaveChangesAsync();
                    return true;
                }
                else return false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}