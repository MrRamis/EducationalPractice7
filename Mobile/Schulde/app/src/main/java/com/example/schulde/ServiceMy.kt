package com.example.schulde

import com.example.schulde.Schedule.DailySchedule
import retrofit2.Call
import retrofit2.http.GET

interface ServiceMy {
    @GET("GetTeacher")
    fun getTeacher() : Call<Teacher>

    @GET("GetFul")
    fun getDailySchedule() : Call<DailySchedule>
}