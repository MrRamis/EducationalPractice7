package com.example.schulde

import android.annotation.SuppressLint
import android.os.Bundle
import android.util.Log
import android.widget.LinearLayout
import androidx.activity.ComponentActivity
import androidx.activity.compose.setContent
import androidx.compose.foundation.clickable
import androidx.compose.foundation.layout.Box
import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.Row
import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.foundation.layout.fillMaxWidth
import androidx.compose.foundation.layout.height
import androidx.compose.foundation.layout.padding
import androidx.compose.foundation.layout.size
import androidx.compose.foundation.layout.width
import androidx.compose.foundation.lazy.LazyColumn
import androidx.compose.foundation.lazy.LazyRow
import androidx.compose.foundation.lazy.items
import androidx.compose.foundation.rememberScrollState
import androidx.compose.foundation.verticalScroll
import androidx.compose.material.icons.Icons
import androidx.compose.material.icons.filled.MoreVert
import androidx.compose.material3.Card
import androidx.compose.material3.Divider
import androidx.compose.material3.DropdownMenu
import androidx.compose.material3.DropdownMenuItem
import androidx.compose.material3.Icon
import androidx.compose.material3.IconButton
import androidx.compose.material3.MaterialTheme
import androidx.compose.material3.Surface
import androidx.compose.material3.Text
import androidx.compose.runtime.Composable
import androidx.compose.runtime.getValue
import androidx.compose.runtime.mutableStateOf
import androidx.compose.runtime.remember
import androidx.compose.runtime.setValue
import androidx.compose.ui.Modifier
import androidx.compose.ui.platform.LocalDensity
import androidx.compose.ui.platform.testTag
import androidx.compose.ui.unit.dp
import androidx.compose.ui.unit.sp
import androidx.lifecycle.lifecycleScope
import com.example.schulde.Schedule.DailyScheduleItem
import com.example.schulde.ui.theme.SchuldeTheme
import kotlinx.coroutines.launch

class MainActivity : ComponentActivity() {
    @SuppressLint("CoroutineCreationDuringComposition", "MutableCollectionMutableState")
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContent {
            SchuldeTheme {
                // A surface container using the 'background' color from the theme
                Surface(
                    modifier = Modifier.fillMaxSize(),
                    color = MaterialTheme.colorScheme.background
                ) {
                    var repository = Repository()
                    var teacher by remember {
                        mutableStateOf(listOf<DailyScheduleItem>())
                    }
                    var items = repository.getDailySchedule()
                    lifecycleScope.launch {
                        items.collect {

                            var li = items.value
                            if (li!=null)
                                teacher=li
                        }
                    }
                    Log.d("mgkit","sdasdasda" +teacher.toString())
                         CreateItems(teacher)
                }
            }
        }
    }
}

@SuppressLint("MutableCollectionMutableState")
@Composable
fun CreateItems(listT : List<DailyScheduleItem>)
{
    Column {
        var r = mutableListOf<DailyScheduleItem>()
        var list by remember { mutableStateOf (r) }
        var expanded by remember { mutableStateOf(false) }
        var expandedy by remember { mutableStateOf(false) }
        Box {
            IconButton(onClick = { expanded = true }) {
                Icon(Icons.Default.MoreVert, contentDescription = "Показать меню")
            }
            DropdownMenu(
                expanded = expanded,
                onDismissRequest = { expanded = false }
            ) {
                Text(
                    "Понедельник",
                    fontSize = 18.sp,
                    modifier = Modifier
                        .padding(10.dp)
                        .clickable(onClick = {
                            list = listT
                                .filter { it.day == "0" }
                                .toMutableList()
                        })
                )

                Divider()
                Text(
                    "Вторник",
                    fontSize = 18.sp,
                    modifier = Modifier
                        .padding(10.dp)
                        .clickable(onClick = {
                            list = listT
                                .filter { it.day == "1" }
                                .toMutableList()
                        })
                )
                Divider()
                Text(
                    "Cреда",
                    fontSize = 18.sp,
                    modifier = Modifier
                        .padding(10.dp)
                        .clickable(onClick = {
                            list = listT
                                .filter { it.day == "2" }
                                .toMutableList()
                        })
                )
                Divider()
                Text(
                    "Четверг",
                    fontSize = 18.sp,
                    modifier = Modifier
                        .padding(10.dp)
                        .clickable(onClick = {
                            list = listT
                                .filter { it.day == "3" }
                                .toMutableList()
                        })
                )
                Divider()
                Text(
                    "Пятница",
                    fontSize = 18.sp,
                    modifier = Modifier
                        .padding(10.dp)
                        .clickable(onClick = {
                            list = listT
                                .filter { it.day == "4" }
                                .toMutableList()
                        })
                )
                Divider()
                Text(
                    "Суббота",
                    fontSize = 18.sp,
                    modifier = Modifier
                        .padding(10.dp)
                        .clickable(onClick = {
                            list = listT
                                .filter { it.day == "5" }
                                .toMutableList()
                        })
                )
            }
        }
        Column {


        Box {
            IconButton(onClick = { expandedy = true }) {
                Icon(Icons.Default.MoreVert, contentDescription = "Показать меню")
            }
            DropdownMenu(
                expanded = expandedy,
                onDismissRequest = { expandedy = false }
            ) {
                Text(
                    "1",
                    fontSize = 18.sp,
                    modifier = Modifier
                        .padding(10.dp)
                        .clickable(onClick = {
                            list = list
                                .filter { it.pair == "1" }
                                .toMutableList()
                        })
                )
                Text(
                    "2",
                    fontSize = 18.sp,
                    modifier = Modifier
                        .padding(10.dp)
                        .clickable(onClick = {
                            list = list
                                .filter { it.pair == "2" }
                                .toMutableList()
                        })
                )

                Divider()
                Text(
                    "3",
                    fontSize = 18.sp,
                    modifier = Modifier
                        .padding(10.dp)
                        .clickable(onClick = {
                            list = list
                                .filter { it.pair == "3" }
                                .toMutableList()
                        })
                )
                Divider()
                Text(
                    "4",
                    fontSize = 18.sp,
                    modifier = Modifier
                        .padding(10.dp)
                        .clickable(onClick = {
                            list = list
                                .filter { it.pair == "4" }
                                .toMutableList()
                        })
                )
                Divider()
                Text(
                    "5",
                    fontSize = 18.sp,
                    modifier = Modifier
                        .padding(10.dp)
                        .clickable(onClick = {
                            list = list
                                .filter { it.pair == "5" }
                                .toMutableList()
                        })
                )
                Divider()
                Text(
                    "6",
                    fontSize = 18.sp,
                    modifier = Modifier
                        .padding(10.dp)
                        .clickable(onClick = {
                            list = list
                                .filter { it.pair == "6" }
                                .toMutableList()
                        })
                )
                Divider()
                Text(
                    "7",
                    fontSize = 18.sp,
                    modifier = Modifier
                        .padding(10.dp)
                        .clickable(onClick = {
                            list = list
                                .filter { it.pair == "7" }
                                .toMutableList()
                        })
                )
            }
        }}
        Column() {


            Text(text = "пара")
            LazyColumn(Modifier.testTag("lazyTag")) {
                items(list)
                {
                    Card(
                        Modifier
                            .fillMaxWidth()
                            .padding(10.dp)
                            .height(60.dp)
                            .testTag("cardTag")
                    )
                    {
                        Row() {
                            Text(
                                it.cabinet ?: "",
                                Modifier
                                    .padding(10.dp)
                                    .testTag("familyTag")
                            )
                            Text(
                                it.teacher ?: "",
                                Modifier
                                    .padding(10.dp)
                                    .testTag("nameTag")
                            )
                            Text(
                                it.droup ?: "",
                                Modifier
                                    .padding(10.dp)
                                    .testTag("nameTag")
                            )

                        }

                    }
                }
            }
        }
    }
}

