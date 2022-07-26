using MedicalNotes.DTO;
using MedicalNotes.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MedicalNotes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetNotes()
        {
            ResponseDTO response = new ResponseDTO();
            try
            {
                using (MedicalNotesContext db = new MedicalNotesContext())
                {
                    List<Note> lista = db.Notes.ToList();
                    response.Success = true;
                    response.Data = lista;
                    response.Message = "Success!";
                }

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Data = ex;
                response.Message = ex.Message;
            }
            return Ok(response);
        }


        [HttpPost]
        public IActionResult AddNotes(RequestDTO request)
        {
            ResponseDTO response = new ResponseDTO();
            try
            {
                using (MedicalNotesContext db = new MedicalNotesContext())
                {
                    Note nota = new Note
                    {
                        Diagnosis = request.Diagnosis,
                        Date = request.Date,
                        Reminder = request.Reminder,
                        DoctorName = request.DoctorName,
                        DoctorInfo = request.DoctorInfo,
                        Recipe = request.Recipe
                    };
                    db.Notes.Add(nota);
                    db.SaveChanges();
                }
                response.Success = true;
                response.Message = "Success!";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Data = ex;
                response.Message = ex.Message;
            }
            return Ok(response);
        }

    }
}

                        