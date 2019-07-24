using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AlgorithmsApp.API.Models;
using AlgorithmsApp.API.Algorithms;
using System;
using Microsoft.Extensions.Configuration;

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

        public async Task<List<AlgorithmStatistic>> GetAlgoritmsStatisticAsync()
        {
            var algorithmsStatistic = await _context.AlgorithmStatistics.ToListAsync();
            return algorithmsStatistic;
        }

        public async Task<bool> AddAloritmStatistic(AlgorithmStatistic algorithmsStatistic)
        {
            try
            {
                await _context.AlgorithmStatistics.AddAsync(algorithmsStatistic);
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<MockData>> GetMocks(){
            return await _context.MockDatas.ToListAsync();
        }

        public async Task<bool> GenerateMocks(int length)
        {
            try
            {
                var isMock = await _context.MockDatas.AnyAsync(m => m.NumberOfElements == length);
                if (!isMock)
                {
                    var gen = new ListGenerator();
                    int[] arr = gen.ListOfIntegers(length);

                    var mock = new MockData()
                    {
                        NumberOfElements = length,
                        SetOfData = string.Join(',', arr)
                    };

                    await _context.MockDatas.AddAsync(mock);
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