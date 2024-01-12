package com.example.schulde

import androidx.compose.ui.test.assertIsDisplayed
import androidx.compose.ui.test.hasText
import androidx.compose.ui.test.junit4.createComposeRule
import androidx.compose.ui.test.onNodeWithTag
import androidx.compose.ui.test.performScrollToNode
import androidx.test.espresso.Espresso.onView
import androidx.test.espresso.matcher.ViewMatchers.isDisplayed
import androidx.test.espresso.matcher.ViewMatchers.withId
import androidx.test.espresso.matcher.ViewMatchers.withTagValue
import androidx.test.ext.junit.rules.ActivityScenarioRule
import androidx.test.platform.app.InstrumentationRegistry
import androidx.test.ext.junit.runners.AndroidJUnit4


import org.junit.Test
import org.junit.runner.RunWith

import org.junit.Assert.*
import org.junit.Rule
import java.util.EnumSet.allOf
import java.util.regex.Pattern.matches

/**
 * Instrumented test, which will execute on an Android device.
 *
 * See [testing documentation](http://d.android.com/tools/testing).
 */
@RunWith(AndroidJUnit4::class)
class ExampleInstrumentedTest {
    @Test
    fun useAppContext() {
        // Context of the app under test.
        val appContext = InstrumentationRegistry.getInstrumentation().targetContext
        assertEquals("com.example.schulde", appContext.packageName)
    }
    @get:Rule
    val composeTestRule = createComposeRule()
    @Test
    fun showElement() {

//        composeTestRule.setContent {
//            CreateItems(list = listOf<Teacher>(
//               // Teacher("Ирина", "Дзюба", "Георгиевна"),
//            ))
//        }

        composeTestRule.onNodeWithTag("lazyTag")
            .performScrollToNode(hasText("Ирина"))
            .performScrollToNode(hasText("Дзюба"))// <- Scroll to the node containing the appropriate text
            .assertIsDisplayed() // <- Assert that it is displayed
    }
}
