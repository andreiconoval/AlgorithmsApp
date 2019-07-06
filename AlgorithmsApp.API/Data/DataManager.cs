using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AlgorithmsApp.API.Models;
using AlgorithmsApp.API.Algorithms;
using System;

namespace AlgorithmsApp.API.Data
{
    public class DataManager
    {
        private readonly DataContext _context;
        public DataManager(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Algorithm>> GetAlgoritmsAsync()
        {
            var algorithms = await _context.Algorithms.ToListAsync();
            return algorithms;
        }

        public async Task<bool> GenerateMocks(int length)
        {
            try{
            var isMock = await _context.MockDatas.AnyAsync(m => m.NumberOfElements == length);
            if (!isMock)
            {
                var gen = new GenerateList();
                int[] arr = gen.ListOfIntegers(length);

                var mock =  new MockData() {
                    NumberOfElements = length,
                    SetOfData = string.Join(',', arr)
                };

                await _context.MockDatas.AddAsync(mock);
                await _context.SaveChangesAsync();
                return true;
            }
            else return  false;
           

            }
            catch {
                return false ;
            }
           
        }
    }
}