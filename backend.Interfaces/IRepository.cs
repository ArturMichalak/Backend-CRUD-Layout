﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Pobranie listy obiektów z repozytorium
        /// </summary>
        /// <param name="count">Liczba elementów pobieranych</param>
        /// <param name="skip">Pomija podaną liczbę elementów i doczytuje kolejne</param>
        /// <returns>zwraca wyszukane rekordy</returns>
        Task<IEnumerable<TEntity>> Get(int count, int skip);

        /// <summary>
        /// Pobranie listy obiektów z repozytorium
        /// </summary>
        /// <returns>zwraca wyszukane rekordy</returns>
        Task<IEnumerable<TEntity>> Get();

        /// <summary>
        /// Pobranie jednego obiektu z repozytorium
        /// </summary>
        /// <param name="id">id poszukiwanego obiektu</param>
        /// <returns>zwraca wyszukany rekord</returns>
        Task<TEntity> Get(int id);

        /// <summary>
        /// Aktualizacja obiektu w repozytorium
        /// </summary>
        /// <param name="o">nowy obiekt ktory ma zastapic obecny</param>
        /// <param name="id">id obiektu modyfikowanego</param>
        /// <returns></returns>
        Task<TEntity> Update(TEntity o, int id);

        /// <summary>
        /// Umieszczenie nowego obiektu w repozytorium
        /// </summary>
        /// <param name="o">obiekt ktory ma zostac zapisany do bazy</param>
        /// <returns></returns>
        Task<TEntity> Insert(TEntity o);

        /// <summary>
        /// Usuniecie obiektu z repozytorium
        /// </summary>
        /// <param name="id">id obiektu usuwanego</param>
        /// <returns></returns>
        Task<TEntity> Delete(int id);
    }
}
