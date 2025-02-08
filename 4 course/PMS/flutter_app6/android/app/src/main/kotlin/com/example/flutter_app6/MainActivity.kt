package com.example.flutter_app6

import android.content.Intent
import android.net.Uri
import android.os.Bundle
import io.flutter.embedding.android.FlutterActivity
import io.flutter.embedding.engine.FlutterEngine
import io.flutter.plugin.common.MethodChannel
import java.util.TimeZone
import android.content.Context
import android.os.BatteryManager


class MainActivity : FlutterActivity() {
    private val TIMEZONE_CHANNEL = "com.example.flutter_app6/timezone"
    private val URL_CHANNEL = "com.example.flutter_app6/url_launcher"
    private val CHANNEL_BATTERY = "com.example.flutter_app6/battery"

    override fun configureFlutterEngine(flutterEngine: FlutterEngine) {
        super.configureFlutterEngine(flutterEngine)

        // Канал для получения часового пояса
        MethodChannel(flutterEngine.dartExecutor.binaryMessenger, TIMEZONE_CHANNEL).setMethodCallHandler { call, result ->
            if (call.method == "getTimeZone") {
                val timeZone = getDeviceTimeZone()
                result.success(timeZone)
            } else {
                result.notImplemented()
            }
        }

        // Канал для открытия браузера с переданным URL
        MethodChannel(flutterEngine.dartExecutor.binaryMessenger, URL_CHANNEL).setMethodCallHandler { call, result ->
            if (call.method == "openBrowser") {
                val url = call.argument<String>("url")
                if (url != null) {
                    openBrowser(url)
                    result.success(null)
                } else {
                    result.error("INVALID_URL", "URL is null or invalid", null)
                }
            } else {
                result.notImplemented()
            }
        }

        MethodChannel(flutterEngine.dartExecutor.binaryMessenger, CHANNEL_BATTERY).setMethodCallHandler { call, result ->
            if (call.method == "getBatteryLevel") {
                val batteryLevel = getBatteryLevel()
                if (batteryLevel != -1) {
                    result.success(batteryLevel)
                } else {
                    result.error("UNAVAILABLE", "Battery level not available.", null)
                }
            } else {
                result.notImplemented()
            }
        }
    }

    // Метод для получения часового пояса устройства
    private fun getDeviceTimeZone(): String {
        val timeZone = TimeZone.getDefault()
        val offset = timeZone.rawOffset / 3600000 // смещение в часах
        val hours = if (offset >= 0) "+$offset" else "$offset"
        return "${timeZone.id} (GMT$hours)"
    }

    // Метод для открытия браузера с переданным URL
    private fun openBrowser(url: String) {
        val intent = Intent(Intent.ACTION_VIEW)
        intent.data = Uri.parse(url)
        intent.flags = Intent.FLAG_ACTIVITY_NEW_TASK
        startActivity(intent)
    }

    private fun getBatteryLevel(): Int {
        val batteryManager = getSystemService(Context.BATTERY_SERVICE) as BatteryManager
        return batteryManager.getIntProperty(BatteryManager.BATTERY_PROPERTY_CAPACITY)
    }
}
