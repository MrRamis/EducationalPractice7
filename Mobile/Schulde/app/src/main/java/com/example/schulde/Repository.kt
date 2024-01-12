package com.example.schulde

import android.util.Log
import com.example.schulde.Schedule.DailySchedule
import kotlinx.coroutines.CoroutineScope
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.flow.MutableStateFlow
import kotlinx.coroutines.launch
import retrofit2.Retrofit
import retrofit2.converter.gson.GsonConverterFactory

class Repository {
    private val scope = CoroutineScope(Dispatchers.IO)
    companion object
    {
        const val BASE = "http://95.165.4.113:5146/"
    }
    private val retrofit = Retrofit.Builder().baseUrl(BASE).addConverterFactory(
        GsonConverterFactory.create()
    ).build()

    private val responseService = retrofit.create(ServiceMy::class.java)

    fun getTeacher() : MutableStateFlow<Teacher?> {
        val result = responseService.getTeacher()
        val stateFlow = MutableStateFlow<Teacher?>(null)
        scope.launch {
            try {
                val res = result.execute()
                Log.d("mgkit", "Res" + res.toString())
                if (res.isSuccessful) {
                    val body = res.body()
                    if (body == null) {
                        stateFlow.emit(null)
                    } else {
                        stateFlow.emit(body)
                        Log.d("mgkit", "BODYGET-" + body.toString())
                    }
                    Log.d("mgkit", "RANDOM-" + body.toString())
                } else {
                    stateFlow.emit(null)
                }
            } catch (ex: Exception) {

            }
        }
        return stateFlow
    }
    fun getDailySchedule() : MutableStateFlow<DailySchedule?> {
        val result = responseService.getDailySchedule()
        val stateFlow = MutableStateFlow<DailySchedule?>(null)
        scope.launch {
            try {
                val res = result.execute()
                Log.d("mgkit", "Res" + res.toString())
                if (res.isSuccessful) {
                    val body = res.body()
                    if (body == null) {
                        stateFlow.emit(null)
                    } else {
                        stateFlow.emit(body)
                        Log.d("mgkit", "BODYGET-" + body.toString())
                    }
                    Log.d("mgkit", "RANDOM-" + body.toString())
                } else {
                    stateFlow.emit(null)
                }
            }catch (ex: Exception){

            }
        }
        return stateFlow
    }
}