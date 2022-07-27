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

        [HttpGet("{Id}")]
        public IActionResult GetNote(int Id)
        {
            ResponseDTO response = new ResponseDTO();
            
            try
            {
                using (MedicalNotesContext db = new MedicalNotesContext())
                {
                    Note nota = db.Notes.Find(Id);
                    if (nota == null)
                    {
                        response.Success = false;
                        response.Data = null;
                        response.Message = "Not Found";
                    }
                    else
                    {
                        response.Success = true;
                        response.Data = nota;
                        response.Message = "Success!";
                    }    
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



        [HttpPut]
        public IActionResult EditNotes(RequestDTO request)
        {
            ResponseDTO response = new ResponseDTO();
            try
            {
                using (MedicalNotesContext db = new MedicalNotesContext())
                {
                    Note nota = db.Notes.Find(request.Id);
                    if (nota == null)
                    {
                        response.Success = false;
                        response.Data = null;
                        response.Message = "Not Found";
                    }
                    else
                    {
                        nota.Diagnosis = request.Diagnosis;
                        nota.Date = request.Date;
                        nota.Reminder = request.Reminder;
                        nota.DoctorName = request.DoctorName;
                        nota.DoctorInfo = request.DoctorInfo;
                        nota.Recipe = request.Recipe;

                        db.Entry(nota).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        db.SaveChanges();

                        response.Success = true;
                        response.Message = "Success!";
                    }
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

        [HttpDelete("{Id}")]
        public IActionResult DeleteNotes(int Id)
        {
            ResponseDTO response = new ResponseDTO();
            try
            {
                using (MedicalNotesContext db = new MedicalNotesContext())
                {
                    Note nota = db.Notes.Find(Id);
                    
                        db.Remove(nota);
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

